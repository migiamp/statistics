const linkedList = [];

    function addElementLinkedList() {
      const newElement = document.getElementById('newElement').value;
      linkedList.push(newElement);
      document.getElementById('newElement').value = '';
      displayLinkedList();
    }

    function deleteElementLinkedList() {
      const deleteElement = document.getElementById('deleteElement').value;
      const index = linkedList.indexOf(deleteElement);
      if (index !== -1) {
        linkedList.splice(index, 1);
      }
      document.getElementById('deleteElement').value = '';
      displayLinkedList();
    }

    function searchElementLinkedList() {
      const searchElement = document.getElementById('searchElement').value;
      const found = linkedList.includes(searchElement);
      if (found) {
        alert(`Element '${searchElement}' found in the linked list.`);
      } else {
        alert(`Element '${searchElement}' not found in the linked list.`);
      }
      document.getElementById('searchElement').value = '';
    }

    function displayLinkedList() {
      const linkedListElement = document.getElementById('linkedList');
      linkedListElement.textContent = 'Linked List: ' + linkedList.join(' -> ');
    }