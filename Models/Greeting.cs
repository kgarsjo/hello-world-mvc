namespace hello_dotnet_mvc.Models {
    public class Greeting {
        public int Id { set; get; }

        public string Name { set; get; }

        public override string ToString() {
            return $"Hello {this.Name}!";
        }
    }
}