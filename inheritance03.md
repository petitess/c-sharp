### Program.cs 
```cs
Post post1 = new Post("Thanks for the birthday wishes", true, "Max");
Console.WriteLine(post1.ToString());

ImagePost post2 = new ImagePost("Checkout my new shoes", "Robert", "http://images.com/shoes.jpg", true);
Console.WriteLine(post2.ToString());
Console.ReadLine();
```
### Post.cs 
```cs
namespace exercise01
{
    internal class Post
    {
        private static int  _currentPostId;
        protected int ID {  get; set; }
        public string Title { get; set; }
        public string SendByUserName { get; set; }
        public bool IsPublic { get; set; }
        //Default constractor
        public Post() 
        {
            ID = 0;
            Title = "My first post";
            IsPublic = true;
            SendByUserName = "Daniel";
        }
        public Post(string title, bool isPublic, string sendByUser) 
        {
            this.ID = GetNextId();
            this.Title = title;
            this.SendByUserName = sendByUser;   
            this.IsPublic = isPublic; 
        }
        protected int GetNextId() 
        {
            return ++_currentPostId;
        }
        public void Update(string title, bool isPublic) 
        {
            this.Title = title;
            this.IsPublic = isPublic;
        }
        //Virtual method override of the ToString mrthod that is inherited from
        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}", this.ID, this.Title, this.SendByUserName);
        }
    }
}
```
### ImagePost.cs 
```cs
namespace exercise01
{
    internal class ImagePost : Post
    {
        public string ImageUrl { get; set; }
         public ImagePost() {}
        public ImagePost(string title, string sendByUserName, string imagesUrl, bool isPublic)
        {
            //The following properties are inherited from Post
            this.ID = GetNextId();
            this.Title = title;
            this.SendByUserName = sendByUserName;  
            this.IsPublic = isPublic;
            //Property ImageUrl is a member of ImagePost
            this.ImageUrl = imagesUrl;
        }
        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} by {3}", this.ID, this.Title, this.ImageUrl, this.SendByUserName);
        }
    }
}
```
