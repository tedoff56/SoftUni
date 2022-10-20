class SmartHike {
    constructor(username){
        this.username = username;
        this.goals = new Map();
        this.listOfHikes = [];
        this.resources = 100;
    }

    showRecord(criteria){
        
        if(this.listOfHikes.length === 0){
            return `${this.username} has not done any hiking yet`
        }

        if(criteria === 'all'){
            let result = 'All hiking records:';
            this.listOfHikes.forEach(h => result += `\n${this.username} hiked ${h.peak} for ${h.time} hours`)

            return result;
        }

        let bestHikes = this.listOfHikes
            .filter(h => h.difficultyLevel === criteria)
            .sort((a, b) => a.time - b.time);

        if(bestHikes.length === 0){
            return `${this.username} has not done any ${criteria} hiking yet`;
        }

        return `${this.username}'s best ${criteria} hike is ${bestHikes[0].peak} peak, for ${bestHikes[0].time} hours`;
    }

    rest(time){
        let gainedResources = Number(time) * 10;
        this.resources += gainedResources;

        if(this.resources > 100){
            this.resources = 100;
            return 'Your resources are fully recharged. Time for hiking!';
        }

        return `You have rested for ${time} hours and gained ${gainedResources}% resources`
    }

    hike(peak, time, difficultyLevel){
        if(!this.goals.has(peak)){
            throw Error(`${peak} is not in your current goals`);
        }

        if(this.resources === 0){
            throw Error("You don't have enough resources to start the hike");
        }

        time = Number(time);

        let usedResources = time * 10;
        let difference = this.resources - usedResources;

        if(difference < 0){
            return "You don't have enough resources to complete the hike";
        }

        this.resources -= usedResources;
        this.listOfHikes.push({ peak, time, difficultyLevel });

        return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
    }

    addGoal(peak, altitude){
        if(this.goals.has(peak)){
            return `${peak} has already been added to your goals`;
        }

        this.goals.set(peak, Number(altitude));
        return `You have successfully added a new goal - ${peak}`;
    }
}

const user = new SmartHike('Vili');
user.addGoal('Musala', 2925);
user.hike('Musala', 8, 'hard');
console.log(user.showRecord('easy'));
user.addGoal('Vihren', 2914);
user.hike('Vihren', 4, 'hard');
console.log(user.showRecord('hard'));
user.addGoal('Rui', 1706);
user.hike('Rui', 3, 'easy');
console.log(user.showRecord('all'));



