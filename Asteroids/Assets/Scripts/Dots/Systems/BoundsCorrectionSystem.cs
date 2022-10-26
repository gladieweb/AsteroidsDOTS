using Dots.Data;
using Dots.Tags.Actions;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Dots.Systems
{
    public class BoundsCorrectionSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            int width = Screen.width/2;
            int height = Screen.height/2;
            Entities
                //.WithEntityQueryOptions(EntityQueryOptions.FilterWriteGroup)
                .WithAll<TagMove>()
                .ForEach(
                    (ref Translation position, in CompositeScale scale
                    ) =>

                    {
                        var scalex = scale.Value.c0.x / 2;
                        var scaley = scale.Value.c1.y / 2;

                        if ((position.Value.x - scalex) > width)
                        {
                            position.Value.x = -width - scalex;
                        }
                        else if (position.Value.x + scalex < -width)
                        {
                            position.Value.x = width + scalex;
                        }

                        if (position.Value.y - scaley > height)
                        {
                            position.Value.y = -height - scaley;
                        }
                        else if (position.Value.y + scaley < -height)
                        {
                            position.Value.y = height + scaley;
                        }
                    }
                ).ScheduleParallel();
        }
    }
}