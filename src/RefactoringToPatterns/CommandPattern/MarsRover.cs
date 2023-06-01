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
    private readonly MoveEast _moveEast;
    private readonly MoveSouth _moveSouth;
    private readonly MoveWest _moveWest;
    private readonly MoveNorth _moveNorth;

    public MarsRover(int x, int y, char direction, string[] obstacles)
    {
        _x = x;
        _y = y;
        _direction = direction;
        _obstacles = obstacles;
        _moveEast = new MoveEast(this);
        _moveSouth = new MoveSouth(this);
        _moveWest = new MoveWest(this);
        _moveNorth = new MoveNorth(this);
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
                switch (_direction)
                {
                    case 'E':
                        _moveEast.Execute();
                        break;
                    case 'S':
                        _moveSouth.Execute();
                        break;
                    case 'W':
                        _moveWest.Execute();
                        break;
                    case 'N':
                        _moveNorth.Execute();
                        break;
                }
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