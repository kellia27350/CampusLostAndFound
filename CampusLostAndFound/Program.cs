using CampusLostAndFound.Controllers;
using CampusLostAndFound.Data;
using CampusLostAndFound.Views;

namespace CampusLostAndFound
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // ── Verify database connection before showing any UI ──────────
            if (!DatabaseHelper.TestConnection(out string dbError))
            {
                MessageBox.Show(
                    $"Cannot connect to the database.\n\n{dbError}\n\n" +
                    "Please check your connection string in App.config and ensure SQL Server is running.",
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // ── Shared controller instances (application-wide singletons) ─
            var accountController = new AccountController();
            var itemController    = new ItemController();
            var claimController   = new ClaimController();

            // ── Main application loop ────────────────────────────────────
            // Show LoginForm → on success show MainForm → repeat until exit
            while (true)
            {
                using var loginForm = new LoginForm(accountController);
                if (loginForm.ShowDialog() != DialogResult.OK)
                    break; // user closed login → exit app

                using var mainForm = new MainForm(accountController, itemController, claimController);
                mainForm.ShowDialog();

                // After MainForm closes (logout), loop back to login
                // If the user is no longer logged in we present login again.
                // If they closed the main form without logging out the loop ends naturally
                // because the loop condition evaluates again.
            }
        }
    }
}
