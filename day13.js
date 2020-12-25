const input = `1011416
41,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,37,x,x,x,x,x,911,x,x,x,x,x,x,x,x,x,x,x,x,13,17,x,x,x,x,x,x,x,x,23,x,x,x,x,x,29,x,827,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,19`.split('\n');

const departureTime = parseInt(input[0]);
const buses = input[1].split(',').filter(x => x !== 'x').map(x => parseInt(x));

let earliestTime = Infinity;
let earliestBus = undefined;

buses.forEach(bus => {
	let time = departureTime + (bus - (departureTime % bus));
	if(time < earliestTime) {
		earliestTime = time;
		earliestBus = bus;
	}
})

console.log((earliestTime - departureTime) * earliestBus);

//part 2 - Chinese remainder theorem
//used some other people's code as inspiration, get the jist of it now
let time = 0;
let buses = input[1].split(',').map(x => parseInt(x));
// var firstBus = buses.splice(0, 1);
let step = buses.splice(0, 1)[0];  //remove the first bus from the list and set the starting value to it

buses.forEach((bus, index) => {
	if(isNaN(bus)) { //we can't filter the 'x' buses out cause we still need the index
		return
	}

	while(true) {
		//if the departureTime is dividable by the index
		if((time + index+1) % bus === 0) {
			step *= bus;
			break;
		}

		time += step;
	}
})

console.log(time);

