namespace Car.Interface
{
    public interface IThrustController
    {
        void Thrust(float torque, float topSpeed = 50f);
    }
}