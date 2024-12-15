List<int> numbers = new List<int> {  2, 2, 3, 4, 5, 6, 7, 8, 9,1, 1, 1, 1, };


var test = numbers.CountBy(x => x).MaxBy(p => p.Value);

var test1 = numbers.CountBy(x => x);



Console.WriteLine($"Month {test.Key} Count {test.Value}");
var a = 0;