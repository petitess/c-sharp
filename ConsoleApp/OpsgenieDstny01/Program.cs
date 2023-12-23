namespace OpsgenieDstny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Opsgenie opsgenieUser = new Opsgenie();
            string nextOnCall = opsgenieUser.GetOpsgenieNextOnCallUser();

            Dstny dstny = new Dstny();
            dstny.LogoutDstnyUsers();
            dstny.LoginDstnyUser(nextOnCall);
        }
    }
}