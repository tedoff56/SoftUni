function constructionCrew(worker){
    if(worker.dizziness === true){
        let waterToTake = worker.weight * 0.1 * worker.experience;
        worker.levelOfHydrated += waterToTake;
        dizziness = false;
    }

    return worker;
}

console.log(constructionCrew({ 
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }));