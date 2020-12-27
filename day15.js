const input = `0,20,7,16,1,18,15`.split(',').map(x => parseInt(x));

function getNumberForTurn(turn = 2020) {
	let numbers = {};
	let index = input.length;
	let lastSpoken = input[index-1];
	input.forEach((x, i) => numbers[x] = [i+1]);

	while(index++ < turn) {
		let spoken = 0;

		if(numbers[lastSpoken].length > 1) {
			let _ = numbers[lastSpoken];
			let l = _.length;
			spoken = _[l - 1] - _[l - 2];
		}

		if(!numbers[spoken]) {
			numbers[spoken] = [];
		}

		numbers[spoken].push(index);
		lastSpoken = spoken;
	}

	return lastSpoken;
}

//part 1
console.log('part 1:', getNumberForTurn(2020));

//part 2, takes about 2 minutes, but I mean I only have to change 1 argument 😳 worth it
console.log('part 2:', getNumberForTurn(30000000));
