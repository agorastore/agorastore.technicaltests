import React, { Component } from 'react';


export class FormulaireCalculPrixVente extends Component<{}, { montantInitial: number, montantCalcule: number, calculTtc: boolean }> {
    static displayName = FormulaireCalculPrixVente.name;

    constructor(props: any) {
        super(props);
        this.state = { montantInitial:0 , montantCalcule: 0, calculTtc: false };


        this.Reset = this.Reset.bind(this);
        this.handleCheckboxChange = this.handleCheckboxChange.bind(this);
        this.setMontant = this.setMontant.bind(this);
        this.lanceCalcul = this.lanceCalcul.bind(this);
        this.DonneAffichage = this.DonneAffichage.bind(this);
    }

    Reset(e: any) {
        e.preventDefault();
        let element = document.getElementById("labelResult");
        if(element != null) element.style.display = 'none';
        this.setState({
            montantInitial: 0,
            calculTtc: false,
            montantCalcule:0
        });
    }

    handleCheckboxChange() {
        this.setState({
            calculTtc: !(this.state.calculTtc)
        });
    };

    setMontant(Event: any) {
        this.setState({
            montantInitial: Event.target.value
        })
    };

    DonneAffichage() {
        let valeur: number = this.state.montantCalcule + (this.state.calculTtc ? this.state.montantCalcule * 0.20 : 0);
        return "Le prix de vente est de " + valeur + " euros " + (this.state.calculTtc ? "TTC" : "HT");
    }

    render() {
        return (

            <div className="containerFormCalcul">
                <form onSubmit={this.lanceCalcul}>
                    <div>
                        <h1>Calcul de prix</h1>
                        <p>
                            <span>Ins&eacute;rez un montant et cliquez sur le bouton "calculer" pour obtenir le prix de vente.
                                <br />
                                Activez le calcul TTC si besoin grace au switch sous le bouton.
                            </span>
                        </p>
                        <div>
                        <label>Montant initial : </label>
                            <input type="number" min="0" max="1000000000" step="0.01" id="MontantInitial" onChange={this.setMontant} value={this.state.montantInitial} />
                         <button className="btn btn-primary" type="submit"  >Calculer</button></div>
                        <div><label>Activez pour un calcul TTC</label></div>
                        <div><label className="switch">
                            <input type="checkbox" checked={this.state.calculTtc} onChange={this.handleCheckboxChange} />
                            <span className="slider round"></span>
                        </label></div>
                        <div><button className="btn btn-secondary" onClick={this.Reset}>r&eacute;initialiser</button></div>
    
                        <div><label id="labelResult">{this.DonneAffichage()}</label></div>
                    </div>
                </form>
            </div>
           
        );
    }

    async lanceCalcul(e: any) {
        e.preventDefault();
        let url: string;
        const constUrl = process.env.REACT_APP_SERVER_URL as string;

        url = constUrl;
        url += "/" + this.state.montantInitial;

        await fetch(url)
            .then((response) => response.json())
            .then((data) => {
                this.setState({ montantCalcule: data });
                let element = document.getElementById("labelResult");
                if (element != null) element.style.display = 'inline'; })
            .catch((error) =>
                alert("erreur : " + error) 
            );

    }
}

export default FormulaireCalculPrixVente
