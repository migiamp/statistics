const randomElements = new Set([1, 2, 3, 4, 5]);

function addElementHashSet() {
    const element = document.getElementById("element").value;
    randomElements.add(element);
    updateOutputHashSet(`Added ${element} to the set.`);
}

function deleteElementHashSet() {
    const element = document.getElementById("element").value;
    if (randomElements.has(element)) {
        randomElements.delete(element);
        updateOutputHashSet(`Deleted ${element} from the set.`);
    } else {
        updateOutputHashSet(`${element} not found in the set.`);
    }
}

function searchElementHashSet() {
    const element = document.getElementById("element").value;
    if (randomElements.has(element)) {
        updateOutputHashSet(`${element} is in the set.`);
    } else {
        updateOutputHashSet(`${element} is not in the set.`);
    }
}

function updateOutputHashSet(message) {
    document.getElementById("outputHashSet").textContent = message;
}