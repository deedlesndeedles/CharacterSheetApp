using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CombatTrackerClient.Tools
{
    class Message
    {
        public static async void msg(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        public static async Task<bool> prompt(string content, UICommandInvokedHandler yes, UICommandInvokedHandler no)
        {
            debug("Promted");

            UICommand yesCommand = new UICommand("Yes", yes);
            UICommand noCommand = new UICommand("No", no);
 
            MessageDialog dialog = new MessageDialog(content);
            //dialog.Options = MessageDialogOptions.None;
            dialog.Commands.Add(yesCommand);
            dialog.Commands.Add(noCommand);

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;

            debug("Dialog not yet shown");

            await dialog.ShowAsync();
            //IUICommand command = await dialog.ShowAsync();

            debug("Dialog shown");

            /*if (command == yesCommand)
            {
                // handle yes command
                debug("Yes!");
                return true;
            }
            else
            {
                // handle no command
                debug("No!");
            }*/
            return true;
        }

        public static void debug(string output)
        {
            System.Diagnostics.Debug.WriteLine(output);
        }
    }
}
