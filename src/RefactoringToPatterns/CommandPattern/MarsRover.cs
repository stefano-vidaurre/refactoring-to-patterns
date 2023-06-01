using System.Linq;

namespace RefactoringToPatterns.CommandPattern;

public class MarsRover
{
    public int _x;
    public int _y;
    private char _direction;
    private readonly string _availableDirections = "NESW";
    public readonly string[] _obstacles;
    public bool _obstacleFound;

    private readonly IDictionary<char, IDirection> _directions;

    public MarsRover(int x, int y, char direction, string[] obstacles)
    {
        _x = x;
        _y = y;
        _direction = direction;
        _obstacles = obstacles;
        _directions = new Dictionary<char, IDirection>()
        {
            { 'N', new MoveNorth(this) },
            { 'S', new MoveSouth(this) },
            { 'W', new MoveWest(this) },
            { 'E', new MoveEast(this) },
        };
    }
        
    public string GetState()
    {
        return !_obstacleFound ? $"{_x}:{_y}:{_direction}" : $"O:{_x}:{_y}:{_direction}";
    }

    public void Execute(string commands)
    {
        foreach(char command in commands)
        {
            if (command == 'M')
            {
                IDirection direction = _directions[_direction];
                direction.Execute();
            }
            else if(command == 'L')
            {
                // get new direction
                var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                if (currentDirectionPosition != 0)
                {
                    _direction = _availableDirections[currentDirectionPosition-1];
                }
                else
                {
                    _direction = _availableDirections[3];
                }
            } else if (command == 'R')
            {
                // get new direction
                var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                if (currentDirectionPosition != 3)
                {
                    _direction = _availableDirections[currentDirectionPosition+1];
                }
                else
                {
                    _direction = _availableDirections[0];
                }
            }
        }
    }
}