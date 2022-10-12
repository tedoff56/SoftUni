class List{
    constructor(){
        this.list = [];
        this.size = this.list.length;
    }

    add(element){
        this.list.push(element);
        this.size = this.list.length;
        this.list.sort((a, b) => a - b)
    }

    remove(index){
        if(index >= 0 && index < this.size){
            this.list.splice(index, 1);
            this.size = this.list.length;
        }
    }

    get(index){
        if(index >= 0 && index < this.size){
            return this.list[index];
        }
    }
}