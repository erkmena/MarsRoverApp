using MarsRoverApp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Model
{
    public interface IVehicle
    {
        Plateau CurrentCoordinates();

        char CurrentDirection();

        void Move(Plateau directionToMove);

        void Turn(char direction);
    }
}
