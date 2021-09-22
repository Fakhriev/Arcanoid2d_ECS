using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

public class VelocityIncreaseWithInertiaResistance : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities
            .ForEach((ref Velocity velocity, in VelocityAcceleration velocityAcceleration, in InertiaResistance inertiaResistance) => {

                if (velocity.isDecreasing == false)
                {
                    float velocityMagnitude = math.sqrt(math.pow(velocity.vector.x, 2) + math.pow(velocity.vector.y, 2));

                    if (velocityMagnitude < velocity.maximum)
                    {
                        velocity.vector += velocityAcceleration.vector * (velocityAcceleration.speed + inertiaResistance.value) * deltaTime;
                    }
                }

            }).Schedule();
    }
}