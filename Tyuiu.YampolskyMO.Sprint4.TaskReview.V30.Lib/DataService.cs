namespace Tyuiu.YampolskyMO.Sprint4.TaskReview.V30.Lib;

public class DataService
{
    // Заполнение матрицы по строкам слева направо.
    public int[,] GetMatrix(string value, int rows, int columns)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (rows <= 0) throw new ArgumentOutOfRangeException(nameof(rows));
        if (columns <= 0) throw new ArgumentOutOfRangeException(nameof(columns));
        if (value.Length != (long)rows * columns)
            throw new ArgumentException("Длина строки должна совпадать с числом элементов матрицы.", nameof(value));

        int[,] matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
            {
                char digit = value[i * columns + j];
                if (digit < '0' || digit > '9')
                    throw new ArgumentException("Строка должна содержать только цифры от 0 до 9.", nameof(value));
                matrix[i, j] = digit - '0';
            }
        return matrix;
    }

    public long Calculate(int[,] matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);
        long product = 1;
        foreach (int number in matrix)
            if (number % 2 == 0)
                product = checked(product * number);
        return product;
    }
}

