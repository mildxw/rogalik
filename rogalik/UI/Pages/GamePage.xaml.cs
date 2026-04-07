using rogalik.Models;
using rogalik.Services;
using rogalik.UI.Pages;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace rogalik.UI.Pages
{
    public partial class GamePage : Page
    {
        private readonly GameEngine _gameEngine = new GameEngine();

        public GamePage()
        {
            InitializeComponent();

            _gameEngine.StartGame();
            RefreshUI();
        }

        private void NextTurnButton_Click(object sender, RoutedEventArgs e)
        {
            _gameEngine.NextTurn();
            RefreshUI();
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_gameEngine.CurrentEnemies.Count > 0)
            {
                _gameEngine.PlayerAttack(0);
            }

            RefreshUI();

            if (_gameEngine.State == GameState.GameOver)
            {
                NavigationService.Navigate(new GameOverPage());
            }
        }

        private void DefendButton_Click(object sender, RoutedEventArgs e)
        {
            _gameEngine.PlayerDefend();
            RefreshUI();

            if (_gameEngine.State == GameState.GameOver)
            {
                NavigationService.Navigate(new GameOverPage());
            }
        }

        private void TakeItemButton_Click(object sender, RoutedEventArgs e)
        {
            _gameEngine.TakeItem();
            RefreshUI();
        }

        private void DiscardItemButton_Click(object sender, RoutedEventArgs e)
        {
            _gameEngine.DiscardItem();
            RefreshUI();
        }

        private void RefreshUI()
        {
            TurnTextBlock.Text = $"Этаж: {_gameEngine.Turn}";
            HpTextBlock.Text = $"HP: {_gameEngine.Player.HP}/{_gameEngine.Player.MaxHP}";

            string weaponText = _gameEngine.Player.Weapon == null
                ? "нет"
                : _gameEngine.Player.Weapon.ToString();

            string armorText = _gameEngine.Player.Armor == null
                ? "нет"
                : _gameEngine.Player.Armor.ToString();

            WeaponTextBlock.Text = $"Оружие: {weaponText}";
            ArmorTextBlock.Text = $"Доспех: {armorText}";
            InventoryWeaponTextBlock.Text = $"Оружие: {weaponText}";
            InventoryArmorTextBlock.Text = $"Доспех: {armorText}";

            LogListBox.ItemsSource = null;
            LogListBox.ItemsSource = _gameEngine.Log.ToList();
            LogListBox.ScrollIntoView(LogListBox.Items[LogListBox.Items.Count - 1]);

            switch (_gameEngine.State)
            {
                case GameState.Exploration:
                    RoomTextBlock.Text = "Комната спокойна. Можно идти дальше.";
                    break;

                case GameState.Battle:
                    RoomTextBlock.Text = "Враги:\n" + string.Join("\n", _gameEngine.CurrentEnemies.Select(e =>
                        $"{e.Name} | HP: {e.HP} | ATK: {e.Attack} | DEF: {e.Defense}"));
                    break;

                case GameState.LootChoice:
                    RoomTextBlock.Text = $"Найден предмет:\n{_gameEngine.PendingItem}";
                    break;

                case GameState.GameOver:
                    RoomTextBlock.Text = "Игрок погиб.";
                    break;
            }

            NextTurnButton.IsEnabled = _gameEngine.State == GameState.Exploration;
            AttackButton.IsEnabled = _gameEngine.State == GameState.Battle;
            DefendButton.IsEnabled = _gameEngine.State == GameState.Battle;
            TakeItemButton.IsEnabled = _gameEngine.State == GameState.LootChoice;
            DiscardItemButton.IsEnabled = _gameEngine.State == GameState.LootChoice;
        }
    }
}