function heroicInventory(input){

    let heroes = [];

    for (const heroData of input) {

        let [name, level, items] = heroData.split(' / ');

        heroes.push({
            name,
            'level': Number(level), 
            'items': items ? items.split(', ') : []
        });

    }

    return JSON.stringify(heroes);
}

console.log(heroicInventory(
    ['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']));