// import { useState, useEffect } from "react";
// import { ListItem } from "./models/ListItem";
// import axios from 'axios';

// export const App = () => {

//     const [items, setItems] = useState([]);
//     const [error, setError] = useState(null);
  
//     // useEffect(() => {
//     //   fetch(import.meta.env.VITE_API_ROOT)
//     //     .then((res) => res.json())
//     //     .then((data: ListItem[]) => setShoppingItems(data))
//     //     .catch((err) => console.error(err.message));
//     // }, []);

//     useEffect(() => {
//         fetchShoppingList();
//       }, []);
  

//     function fetchShoppingList() {
//         axios.get('http://localhost:5046/api/ShoppingList')
//             .then(response => {
//                 setItems(response.data)
//             })
//             .catch(error => {
//                 setError(error);               
//             })
//     }

//     return (
//         <>
//             <div className="main">
//             <div className="items-container">
//           <div className="content">
//             {Items?.map((item, idx) => {
//               return (
//                 <ItemCard
//                   key={idx}
//                   item={item}
//                   setDeleted={setDeleted}
//                   deleted={deleted}
//                   setCompleted={setCompleted}
//                   completed={completed}
//                 />
//               );
//             })}
//           </div>
//         </div>
//             </main>
//         </>
//     )
// }