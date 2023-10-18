let array = [];

        function generateArray() {
            const arrayLength = parseInt(document.getElementById('arrayLength').value);
            array = Array.from({ length: arrayLength }, () => Math.floor(Math.random() * 100));
            displayArray();
        }

        function displayArray() {
            document.getElementById('resultArr').innerHTML = `Array: [${array.join(', ')}]`;
        }

        function addElementArr() {
            console.log(document.getElementById('addElementArr').value);
            const element = parseInt(document.getElementById('addElementArr').value);
            console.log(element);
            array.push(element);
            console.log(array);
            displayArray();
        }

        function deleteElementArr() {
            const element = parseInt(document.getElementById('deleteElementArr').value);
            console.log(array);
            const index = array.indexOf(element);
            if (index > -1) {
                array.splice(index, 1);
                displayArray();
                console.log(array);
            } else {
                document.getElementById('result').innerHTML = `Element not found in the array.`;
            }
        }

        function searchElementArr() {
            const element = parseInt(document.getElementById('searchElementArr').value);
            const index = array.indexOf(element);

            if (index > -1) {
                document.getElementById('resultArr').innerHTML = `Element found at index ${index}.`;
            } else {
                document.getElementById('resultArr').innerHTML = `Element not found in the array.`;
            }
        }