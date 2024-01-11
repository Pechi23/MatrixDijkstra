using MatrixDijkstra;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;

StreamReader sr = new StreamReader("input.txt");


string buffer;
List<string> bufferList = new List<string>();
while ((buffer = sr.ReadLine()) != null)
    bufferList.Add(buffer);

string[] line;
int[,] matrix = new int[bufferList.Count, bufferList.Count];

for (int i = 0; i < bufferList.Count; i++)
{
    line = bufferList[i].Split(' ');
    for (int j = 0; j < line.Length; j++)
        matrix[i, j] = int.Parse(line[j]); 
}

void AddValueToMatrix(int[,] mat,int value)
{
    for (int i = 0; i < mat.GetLength(0); i++)
        for (int j = 0; j < mat.GetLength(1); j++)
            mat[i, j] += value;
}

int[,] distMat = new int[bufferList.Count,bufferList.Count];
int inf = int.MaxValue; 

AddValueToMatrix(matrix,1);
AddValueToMatrix(distMat, inf);
AfisMatrix(matrix);
int n = matrix.GetLength(0);
int m = matrix.GetLength(1);
int[] dx = { -1, 0, 1, 0 };
int[] dy = { 0, 1, 0, -1 };

Solve(0, 0, n - 1, m - 1);
AfisMatrix(distMat);



void Solve(int istart,int jstart, int iend, int jend)
{
    distMat[istart,jstart] = matrix[istart,jstart];
    Queue<Tridata> queue = new Queue<Tridata>();
    queue.Enqueue(new Tridata(istart, jstart, distMat[istart, jstart]));
    
    while(queue.Any())
    {
        Tridata extracted = queue.Dequeue();

        for (int k = 0; k < 4; k++)
        {
            int newI = extracted.i + dx[k];
            int newJ = extracted.j + dy[k];
            if (inMat(newI,newJ))
                if (distMat[extracted.i, extracted.j] + matrix[newI, newJ] < distMat[newI, newJ])
                {
                    distMat[newI, newJ] = distMat[extracted.i, extracted.j] + matrix[newI, newJ];
                    queue.Enqueue(new Tridata(newI, newJ, distMat[newI, newJ]));
                }
        }
    }
    Console.WriteLine(distMat[iend, jend]);
}

bool inMat(int i,int j)
{
    return i >= 0 && j >= 0 && i < matrix.GetLength(0) && j < matrix.GetLength(1);
}
void AfisMatrix(int[,] mat)
{
    for (int i = 0; i < mat.GetLength(0); i++) {
        for (int j = 0; j < mat.GetLength(1); j++)
            Console.Write($"{mat[i, j]} ");
        Console.WriteLine();
    }
    Console.WriteLine();
}

