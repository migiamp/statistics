let sortedArray = [];

function addElementSortedList() {
    const input = document.getElementById("sortedList").value;
    const number = parseInt(input);
    if (!isNaN(number)) {
        sortedArray.push(number);
        sortedArray.sort((a, b) => a - b);
        document.getElementById("outputSortedList").textContent = `Added ${number}. Sorted List: ${sortedArray}`;
    }
}

function deleteElementSortedList() {
    const input = document.getElementById("sortedList").value;
    const number = parseInt(input);
    const index = sortedArray.indexOf(number);
    if (index !== -1) {
        sortedArray.splice(index, 1);
        document.getElementById("outputSortedList").textContent = `Deleted ${number}. Sorted List: ${sortedArray}`;
    } else {
        document.getElementById("outputSortedList").textContent = `${number} not found in the list.`;
    }
}

function searchElementSortedList() {
    const input = document.getElementById("sortedList").value;
    const number = parseInt(input);
    const index = binarySearch(sortedArray, number);
    if (index !== -1) {
        document.getElementById("outputSortedList").textContent = `${number} found at index ${index}.`;
    } else {
        document.getElementById("outputSortedList").textContent = `${number} not found in the list.`;
    }
}

function binarySearch(arr, target) {
    let left = 0;
    let right = arr.length - 1;

    while (left <= right) {
        const mid = Math.floor((left + right) / 2);

        if (arr[mid] === target) {
            return mid;
        }

        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    return -1;
}