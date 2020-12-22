const adapters = `48
171
156
51
26
6
80
62
65
82
130
97
49
31
142
83
75
20
154
119
56
114
92
33
140
74
118
1
96
44
128
134
121
64
158
27
17
101
59
12
89
88
145
167
11
3
39
43
105
16
170
63
111
2
108
21
146
77
45
52
32
127
147
76
58
37
86
129
57
133
120
163
138
161
139
71
9
141
168
164
124
157
95
25
38
69
87
155
135
15
102
70
34
42
24
50
68
169
10
55
117
30
81
151
100
162
148
0`.split('\n').map(x => parseInt(x)).sort((a, b) => (a > b)-1); // => true = 0, false = -1

//part 1
let currentJoltage = 0; //padum tssk
let oneJoltageDiff = 0;
let threeJoltageDiff = 1;

adapters.forEach(x => {
	if(x === currentJoltage + 1) {
		oneJoltageDiff++;
	} else if(x === currentJoltage+3) {
		threeJoltageDiff++;
	}

	currentJoltage = x;
});

console.log(oneJoltageDiff * threeJoltageDiff);

//part 2
//@see https://www.youtube.com/watch?v=cE88K2kFZn0

//Dynamic Programming
const highestAdapter = adapters[adapters.length-1];
let solvedDPs = [];

//The number of ways to complete the adapter chain
function dp(x) {
	if(x === adapters.length-1) {
		return 1;
	}

	//if we already calculated the paths this number has, reuse it
	if(solvedDPs[x]) {
		return solvedDPs[x];
	}

	//calculate the amount of paths this number has
	let answer = 0;
	for(let i = x+1; i < x+4; i++) {
		if(adapters[i] - adapters[x] <= 3) {
			answer += dp(i);
		}
	}

	//save the path for line 140
	solvedDPs[x] = (answer);
	return answer;
}

console.log(dp(0));
