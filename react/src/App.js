import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Manager from './Manager/LoginManager';
import Costumer from './Costumer/LoginCostumer';
import Enter from './Enter';
import ListOfPressent from './Costumer/ListOfPresent';
import { ReactFinalFormDemo } from './Costumer/registerrrrr';
import ShoppingCart from './Costumer/shoppingCart';
import ProductsDemo from './Manager/ListOfPresent_M'
import { useNavigate } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        {/* <Route path="/" element={<Enter />} /> */}
        {/* <Route path="/" element={<ListOfPressent />} /> */}
        <Route path='/Manager' element={<Manager />} />
        <Route path='/Costumer' element={<Costumer />} />
        <Route path='/Register' element={<ReactFinalFormDemo />} />
        <Route path='/ListOfPressent' element={<ListOfPressent />} />
        <Route path='/shoppingCart' element={<ShoppingCart />} />
        {/* manager */}
        {/* <Route path='/PresentManager' element={<ProductsDemo />} /> */}
        <Route path='/' element={<ProductsDemo />} />


      </ Routes>
    </BrowserRouter>
    // {/* //  <Enter></Enter> */}
    //  {/* <ListOfPressent></ListOfPressent> */}
    // {/* //  <ShoppingCart></ShoppingCart> */}
    // {/* <ReactFinalFormDemo></ReactFinalFormDemo> */}
    // {/* <Manager></Manager> */}
  );
}

export default App;

