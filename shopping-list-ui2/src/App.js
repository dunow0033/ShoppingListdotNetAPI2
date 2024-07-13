// import logo from './logo.svg';
// import './App.css';

// function App() {
//   return (
//     <div className="App">
//       <header className="App-header">
//         <img src={logo} className="App-logo" alt="logo" />
//         <p>
//           Edit <code>src/App.js</code> and save to reload.
//         </p>
//         <a
//           className="App-link"
//           href="https://reactjs.org"
//           target="_blank"
//           rel="noopener noreferrer"
//         >
//           Learn React
//         </a>
//       </header>
//     </div>
//   );
// }

// export default App;



import { useState, useEffect } from "react";
//import { ListItem } from "./models/ListItem";
import ShoppingListItem from './ShoppingListItem';
import { Button } from "./components/utils/Button.tsx";
﻿import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCartPlus } from '@fortawesome/free-solid-svg-icons';
import axios from 'axios';

function App() {

    const [items, setItems] = useState([]);
    const [error, setError] = useState(null);
    const [addItemText, setAddItemText] = useState('');
  
    // useEffect(() => {
    //   fetch(import.meta.env.VITE_API_ROOT)
    //     .then((res) => res.json())
    //     .then((data: ListItem[]) => setShoppingItems(data))
    //     .catch((err) => console.error(err.message));
    // }, []);

    useEffect(() => {
        fetchShoppingList();
      }, []);
  

    function fetchShoppingList() {
        axios.get('http://localhost:5046/api/ShoppingList')
            .then(response => {
                setItems(response.data)
            })
            .catch(error => {
                setError(error);               
            })
    }

    function addItem(itemName) {
      if(itemName === '') {
        return;
      }

      axios.post('http://localhost:5046/api/ShoppingList', {
        item: itemName
      }, {
        headers: {
          'Content-Type': 'application/json'
        }
      })
      .then(response => {
        fetchShoppingList();
      })
      .catch(error => {
        console.error('There was an error adding the item!', error);
      });

      setAddItemText('');
    }

    function toggleIsPickedUp(id) {
      setItems(items.map(item => {
        if(item.id === id) {
          axios.patch(`http://localhost:5046/api/ShoppingList/${id}`, {
            params: {
              isPickedUp: !item.isPickedUp
            }
          })
          .then(res => {

          })
          .catch(error => {
            console.error("There was an error updating the item: ", error);
          });

          return { ...item, isPickedUp: !item.isPickedUp };
        } else {
          return item;
        }
      }));
    }

    function deleteItem(id) {
      if(id === null) {
        return;
      }

      axios.delete(`http://localhost:5046/api/ShoppingList/${id}`)
        .then(res => res);

        setItems(items.filter(item => item.id !== id));
    }

    return (
      <>
      <div className="shopping-list">   
        <div className="shopping-list-item">
          <input
            value={addItemText}
            className="shopping-list-add-item-input"
            onChange={e => setAddItemText(e.target.value)}
            placeholder="Add Item..."
            onKeyDown={event => {
              if(event.key === "Enter") {
                addItem(addItemText);
              }
            }}
            />

          <Button
            style={{
              padding: "0.6em 1.2em",
              borderRadius: "8px",
              width: "150px",
              alignSelf: "center",
            }}
            onClick={() => addItem(addItemText)}>
              Add item
            </Button>


            {/* <button onClick={() => addItem(addItemText)}>
              <FontAwesomeIcon icon={faCartPlus} /> 
            </button> */}
        </div>
      
          <div className='shopping-list'>
                { items.length === 0 && <h3>Shopping List is Empty</h3> }
                { items.length > 0 &&
                  items.map(item => (
                    <ShoppingListItem
                      key={item.id}
                      item={item}
                      deleteItem={deleteItem}
                      toggleIsPickedUp = {toggleIsPickedUp}
                    />
            ))
          }
        </div>
        </div>
        </>
    )
}

export default App;
