List<int> numbers = new List<int> {  2, 2, 3, 4, 5, 6, 7, 8, 9,1, 1, 1, 1, };


var test = numbers.CountBy(x => x).MaxBy(p => p.Value);

var test1 = numbers.CountBy(x => x);



Console.WriteLine($"Month {test.Key} Count {test.Value}");
var a = 0;


var person = new List<Person>()
{
    new Person{ id=1,name="aaa",value=1},
    new Person{ id=2,name="bbb",value=2},
    new Person{ id=3,name="ccc",value=2},
    new Person{ id=4,name="ddd",value=5},
    new Person{ id=5,name="eee",value=5},
    new Person{ id=6,name="fff",value=5},

};

//ใครบางที่ได้คะแนนสูงสุด
var m = person.Max(px=>px.value);
var maxList = person.Where(px=>px.value.Equals(m));


//คนที่ได้คะแนนสูงสุด 3 คนแรก
var maxData = person.OrderByDescending(px=>px.value).Take(3).ToList();
maxData.ForEach(x => Console.WriteLine($"{x.id} {x.name} {x.value}"));


class Person
{
    public int id;
    public string name;
    public int value;
}

//order, distinct, groupby