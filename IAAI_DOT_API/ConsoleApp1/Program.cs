List<int> scores = [3, 45, 87 ,97, 92, 100, 81, 60];

scores.Sort();
IEnumerable<string> scoresQuery =
                from score in scores
                where score > 80
                orderby score descending
                // select score;
                select $"The score is {score}"; //This is a string interpolation

var scoreQuery1 = scores.Where(s => s > 80).
                   OrderByDescending(s => s);

//The query doesn't execute until foreach starts iterating.
foreach (var i in scoresQuery)
{
   Console.WriteLine(i);
}
return;