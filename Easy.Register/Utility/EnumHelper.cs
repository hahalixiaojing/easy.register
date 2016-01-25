

namespace Easy.Register.Utility
{
    public class EnumHelper
    {
        public static string DirectoryTypHelper(int directoryType)
        {
            string message = "";
            switch (directoryType)
            {
                case 1:
                    message = "消费者";
                    break;
                case 2:
                    message = "提供者";
                    break;
                case 3:
                    message = "消费者提供者";
                    break;
            }
            return message;
        }
    }
}