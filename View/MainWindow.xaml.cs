using System.Text;
using System.Windows;
using Figure = Model.Figure;
using Point = Model.Point;
using Line = Model.Line;
using Ellipse = Model.Ellipse;
using Rectangle = Model.Rectangle;
using ViewModel = ViewModel.ApplicationViewModel;
using ViewModel;
namespace View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IList<Figure> _figures = new List<Figure>();
    ApplicationViewModel viewModel = new ApplicationViewModel();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowFiguresListButtonClick(object sender, RoutedEventArgs e)
    {
        var builder = new StringBuilder();

        builder.AppendLine("Фигуры:");

        builder.AppendLine("~~~~~~~~~~~~");
        foreach (var figure in _figures)
        {
            builder.AppendLine(figure.ToString());
            builder.AppendLine($"Центр фигуры - {figure.GetCenterPoint()}");
            builder.AppendLine($"Площадь фигуры - {figure.GetSquare()}");
            builder.AppendLine($"Очерчивающий прямоугольник - {figure.GetBoxRectangle()}");
            builder.AppendLine("~~~~~~~~~~~~");
        }

        MessageBox.Show(builder.ToString());
    }

    private void CreateLineOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _figures.Add(viewModel.ParseLineFromString(LineCoordBox.Text));
        }
        catch (Exception)
        {
            MessageBox.Show("Введите 2 точки через точку с запятой. Каждую точку с новой строки");
        }
    }

    private void CreatePointOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _figures.Add(viewModel.ParsePointFromString(PointCoordBox.Text));
        }
        catch (Exception)
        {
            MessageBox.Show("Введите точку через точку с запятой");
        }
    }

    private void CreateEllipseClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _figures.Add(viewModel.ParseEllipseFromString(EllipseCoordbox.Text));
        }
        catch (Exception)
        {
            MessageBox.Show("Введите точку через точку с запятой и радиус с новой строки");
        }
    }

    private void CreateRectangleBox(object sender, RoutedEventArgs e)
    {
        try
        {
            _figures.Add(viewModel.ParseRectangleFromString(RectangleCoordBox.Text));
        }
        catch (Exception)
        {
            MessageBox.Show("Введите 4 точки через точку с запятой. Каждую точку с новой строки");
        }
    }
}