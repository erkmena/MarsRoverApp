using MarsRoverApp.Model;
using MarsRoverApp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Helper
{
    public class VehicleHelper
    {

        public static IVehicle ProcessData(string rawData, IVehicle vehicle, Plateau plateau)
        {
            rawData = rawData.Trim();
            foreach (char nextCommand in rawData)
            {
                char genericCommand = Convert.ToChar(nextCommand.ToString().ToUpper());
                if (genericCommand == 'M')
                {
                    MoveVehicle(vehicle, plateau);
                }

                else if (genericCommand == 'L' || genericCommand == 'R')
                {
                    TurnVehicle(vehicle, genericCommand);
                }

                else
                {
                    throw new NotImplementedException();
                }
            }

            return vehicle;
        }


        public static void MoveVehicle(IVehicle vehicle, Plateau plateau)
        {
            Plateau directionToMove = GetDirectionToMove(vehicle);
            CheckForBoundaries(vehicle.CurrentCoordinates(), directionToMove, plateau);

            vehicle.Move(directionToMove);
        }

        public static void CheckForBoundaries(Plateau currentCoordinates, Plateau directionToMove, Plateau originalPlateau)
        {
            int predictedXAxis = currentCoordinates.XAxis + directionToMove.XAxis;
            int predictedYAxis = currentCoordinates.YAxis + directionToMove.YAxis;

            if (predictedXAxis > originalPlateau.XAxisLength || predictedXAxis < 0)
            {
                directionToMove.XAxis = 0;
            }
            if(predictedYAxis > originalPlateau.YAxisLength || predictedYAxis < 0)
            {
                directionToMove.YAxis = 0;
            }
        }

        public static void TurnVehicle(IVehicle vehicle, char sideToTurn)
        {
            char directionToTurn = GetDirectionToTurn(vehicle, sideToTurn);
            vehicle.Turn(directionToTurn);
        }

        public static char GetDirectionToTurn(IVehicle vehicle, char sideToTurn)
        {
            char directionToTurn;

            if (sideToTurn.ToString().ToUpper() == "L")
            {
                switch (Convert.ToChar(vehicle.CurrentDirection()))
                {
                    case Direction.East:
                        directionToTurn = Direction.North;
                        break;
                    case Direction.North:
                        directionToTurn = Direction.West;
                        break;
                    case Direction.South:
                        directionToTurn = Direction.East;
                        break;
                    case Direction.West:
                        directionToTurn = Direction.South;
                        break;

                    default:
                        throw new NotImplementedException();
                        break;
                }
            }
            else if (sideToTurn.ToString().ToUpper() == "R")
            {
                switch (Convert.ToChar(vehicle.CurrentDirection()))
                {
                    case Direction.East:
                        directionToTurn = Direction.South;
                        break;
                    case Direction.North:
                        directionToTurn = Direction.East;
                        break;
                    case Direction.South:
                        directionToTurn = Direction.West;
                        break;
                    case Direction.West:
                        directionToTurn = Direction.North;
                        break;

                    default:
                        throw new NotImplementedException();
                        break;
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            return directionToTurn;
        }

        public static Plateau GetDirectionToMove(IVehicle vehicle)
        {
            Plateau directionToMove = new Plateau(1,1);
            switch (Convert.ToChar(vehicle.CurrentDirection()))
            {
                case Direction.East:
                    directionToMove.XAxis = 1;
                    break;
                case Direction.North:
                    directionToMove.YAxis = 1;
                    break;
                case Direction.South:
                    directionToMove.YAxis = -1;
                    break;
                case Direction.West:
                    directionToMove.XAxis = -1;
                    break;

                default:
                    throw new NotImplementedException();
                    break;
            }
            return directionToMove;
        }
    }
}
