import React, { useState } from 'react';
import './App.css';

function App() {
    const [sellingPrice, setSellingPrice] = useState();


    return (
        <div className="App">
            <header className="App-header">
                <h1>Pricing</h1>
            </header>

            <form>
                <label htmlFor="initialPrice">Initial Price</label>
                <input id="initialPrice" type="number"/>
                <label><input type="checkbox"/>Include VAT</label>
                <button>Reset</button>
                <button>Calculate</button>
            </form>

            <div>
                {sellingPrice && `Selling price is ${sellingPrice}`}
            </div>
        </div>
    );
}

export default App;
