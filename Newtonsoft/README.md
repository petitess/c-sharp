https://json2csharp.com

https://codebeautify.org

### Program.cs 
```cs
internal class Program
{
    private static async Task Main(string[] args)
    {
        string url = "https://my-json-server.typicode.com/typicode/demo/posts";
        //A http client to send the get request
        HttpClient httpClient = new HttpClient();

        try
        {
            var httpResponseMessage = await httpClient.GetAsync(url);
            //Read the string from response's content
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            //Print the JSON content
            await Console.Out.WriteLineAsync(jsonResponse);
            //Deserialize the JSON response into a C# array of type Post[]
            var myPost = JsonConvert.DeserializeObject<Post[]>(jsonResponse);
            //Print the array objects using a foreach loop
            foreach (var post in myPost)
            {
                Console.WriteLine($"{post.Id}: {post.Title}");
            }
        }
        catch (Exception ex)
        {   
            Console.WriteLine(ex.Message);
        }
        finally { httpClient.Dispose(); }
    }
}
```
### Post.cs 
```cs
namespace json01
{
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
```
