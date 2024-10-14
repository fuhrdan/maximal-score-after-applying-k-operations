//*****************************************************************************
//** 2530. Maximal Score After Applying K Operations    leetcode             **
//*****************************************************************************


// Swap two elements in an array
void swap(int* a, int* b) {
    int temp = *a;
    *a = *b;
    *b = temp;
}

// Heapify-down function to maintain max-heap property
void heapifyDown(int* heap, int heapSize, int idx) {
    int largest = idx;
    int leftChild = 2 * idx + 1;
    int rightChild = 2 * idx + 2;

    if (leftChild < heapSize && heap[leftChild] > heap[largest]) {
        largest = leftChild;
    }
    if (rightChild < heapSize && heap[rightChild] > heap[largest]) {
        largest = rightChild;
    }

    if (largest != idx) {
        swap(&heap[idx], &heap[largest]);
        heapifyDown(heap, heapSize, largest);
    }
}

// Build a max heap from the nums array
void buildMaxHeap(int* heap, int heapSize) {
    for (int i = (heapSize / 2) - 1; i >= 0; i--) {
        heapifyDown(heap, heapSize, i);
    }
}

// Function to get the maximum possible score after k operations
long long maxKelements(int* nums, int numsSize, int k) {
    // Allocate memory for a heap
    int* heap = (int*)malloc(numsSize * sizeof(int));
    
    // Copy elements from nums to the heap
    for (int i = 0; i < numsSize; i++) {
        heap[i] = nums[i];
    }

    // Build the initial max-heap
    buildMaxHeap(heap, numsSize);

    long long score = 0;

    for (int i = 0; i < k; i++) {
        // The largest value is at the root of the heap (index 0)
        int maxVal = heap[0];
        score += maxVal;

        // Update the max value with ceil(maxVal / 3)
        int newVal = (maxVal + 2) / 3;

        // Replace the root of the heap with the new value
        heap[0] = newVal;

        // Re-heapify to maintain the max-heap property
        heapifyDown(heap, numsSize, 0);
    }

    free(heap); // Free allocated memory
    return score;
}