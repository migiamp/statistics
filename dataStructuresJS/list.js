let list = [];

        function generateList() {
            const listLength = parseInt(document.getElementById('listLength').value);
            list = Array.from({ length: listLength }, () => Math.floor(Math.random() * 100));
            displayList();
        }

        function displayList() {
            document.getElementById('resultList').innerHTML = `List: [${list.join(', ')}]`;
        }

        function addElementList() {
            const element = parseInt(document.getElementById('addElementList').value);
            list.push(element);
            console.log(list);
            displayList();
        }

        function deleteElementList() {
            const element = parseInt(document.getElementById('deleteElementList').value);
            const index = list.indexOf(element);
            if (index !== -1) {
                list.splice(index, 1);
                displayList();
                console.log(list);
            } else {
                document.getElementById('resultList').innerHTML = `Element not found in the list.`;
            }
        }

        function searchElementList() {
            const element = parseInt(document.getElementById('searchElementList').value);
            const index = list.indexOf(element);
            if (index !== -1) {
                document.getElementById('resultList').innerHTML = `Element found at index ${index}.`;
            } else {
                document.getElementById('resultList').innerHTML = `Element not found in the list.`;
            }
        }