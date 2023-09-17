import React, { useState } from 'react';
import './App.css';

function App() {
    const [initialPrice, setInitialPrice] = useState(0);
    const [sellingPrice, setSellingPrice] = useState(0);
    const [includeVat, setIncludeVAT] = useState(false);

    function resetData(): void {
        setSellingPrice(0);
        setIncludeVAT(false);
    }

    function toggleIncludeVAT(): void {
        setIncludeVAT(includeVat => !includeVat)
    }

    function updateInitialPrice(e: React.ChangeEvent<HTMLInputElement>) {
        setInitialPrice(parseFloat(e.target.value))
    }

    function calculatePricing() {
        fetch(`https://localhost:7260/calculate-pricing?initialPrice=${sellingPrice}&includeVAT=${includeVat}`)
            .then((res) => res.json())
            .then(pricing => setSellingPrice(pricing.SellingPrice))
    }

    return (
        <div className="App">
            <header className="App-header">
                <h1>Pricing</h1>
            </header>

            <form>
                <label htmlFor="initialPrice">Initial Price</label>
                <input id="initialPrice" type="number" value={initialPrice} onChange={(e) => updateInitialPrice(e)} />
                <label><input type="checkbox" value={`${includeVat}`} onChange={toggleIncludeVAT}/>Include VAT</label>
                <button onClick={(e) => {
                    e.preventDefault();
                    resetData();
                }}>Reset</button>
                <button onClick={(e) => {
                    e.preventDefault();
                    calculatePricing();
                }}>Calculate</button>
            </form>

            <div>
                {sellingPrice !== 0 && `Selling price is ${sellingPrice}`}
            </div>
        </div>
    );
}

export default App;
