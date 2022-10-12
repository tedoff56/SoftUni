function sortTickets(ticketDescriptions, sortingCriterion){

    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let result = [];

    for(let ticketDescription of ticketDescriptions){
        let [destinationName, price, status] = ticketDescription.split('|');

        let ticket = new Ticket(destinationName, price, status);
        result.push(ticket);
    }

    switch(sortingCriterion){
        case 'destination': result.sort((a, b) => a.destination.localeCompare(b.destination));
            break;
        case 'price': result.sort((a, b) => a.price - b.price);
            break;
        case 'status': result.sort((a, b) => a.status.localeCompare(b.status));
            break;
    }

    return result;
}

console.log(sortTickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'));