class footballTeam{
    constructor(clubName, country){
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = new Map();
    }

    transferWindowResult(){
        let resultStr = "Players list:";

        let resultPlayers = Array.from(this.invitedPlayers);
        resultPlayers.sort((a, b) => a[0].localeCompare(b[0])).forEach(p => resultStr += `\nPlayer ${p[0]}-${p[1].playerValue}`);

        return resultStr;
    }

    ageLimit(name, age){
        age = Number(age);

        if(!this.invitedPlayers.has(name)){
            throw Error(`${name} is not invited to the selection list!`);
        }

        let player = this.invitedPlayers.get(name);
        if(player.age < age){
            let difference = age - player.age;

            if(difference < 5){
                return `${name} will sign a contract for ${difference} years with ${this.clubName} in ${this.country}!`;
            }

            return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`
        }
        
        return `${name} is above age limit!`
    }

    signContract(selectedPlayer){
        let [name, playerOffer] = selectedPlayer.split('/');
        playerOffer = Number(playerOffer);

        if(!this.invitedPlayers.has(name)){
            throw Error(`${name} is not invited to the selection list!`)
        }

        let player = this.invitedPlayers.get(name);
        if(playerOffer < player.playerValue){
            let priceDifference = this.invitedPlayers[name].playerValue - playerOffer;
            throw Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`)
        }

        player.playerValue = 'Bought';
        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`
    }

    newAdditions(footballPlayers){
        let result = [];
        for (let playerData of footballPlayers) {
            let [name, age, playerValue] = playerData.split('/');
            age = Number(age);
            playerValue = Number(playerValue);

            if(!this.invitedPlayers.has(name)){
                this.invitedPlayers.set(name, {age, playerValue});
                result.push(name);
                continue;
            }

            let player = this.invitedPlayers.get(name);
            if(playerValue > player.playerValue){
                player.playerValue = playerData;
                continue;
            }

        }
        return `You successfully invite ${result.join(', ')}.`;
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());



