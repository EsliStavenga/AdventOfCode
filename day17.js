//create an object where the key is the layer and the value is the actual layer data
var initialState = {"0": `.#.
..#
###`.split('\n').map(row => row.split('').map(cube => cube === '#'))}; //convert . (inactive) to false and # (active) to true

var currentState = initialState;
var newState = JSON.parse(JSON.stringify(currentState));

for(const layer in initialState) {
	const layerData = initialState[layer];
	const rowLength = layerData.length;

	layerData.forEach((row, rowIndex) => {
		const cubeCount = row.length;

		row.forEach((isActive, cubeIndex) => {
			let activeCount = 0;
			let inactiveCount = 0;

			for(let y = clamp(rowIndex - 1, 0, rowLength), max = clamp(rowIndex + 1, 0, rowLength); y < max; y++) {
				for(let x = clamp(cubeIndex - 1, 0, cubeCount), max = clamp(cubeIndex + 1, 0, cubeCount); x < max; x++) {
					if(initialState[layer][y][x] === '.') {
						inactiveCount++;
					} else {
						activeCount++;
					}
				}
			}

			newState[layer][rowIndex][cubeIndex] = (isActive && (activeCount === 2 || activeCount === 3)) || (!isActive && activeCount === 3);
		});
	});
}

console.log(newState);

function clamp(val, min, max) {
	return Math.min(max, Math.max(val, min));
}
