# Parametric curves

This project is a programming exercise that implements multiple algorithms in order to work around parametric curves.

## Cubic Hermite spline

The equation of the cubic hermite interpolation allows to plot a curve using :
* *P0* as its starting point
* *P1* as its ending point 
* *V0* and *V1* as their respective tangents.

![hermite values 1](https://github.com/vclimpont/parametric-curves/blob/main/Images/hermite1_values.PNG)
![hermite render 1](https://github.com/vclimpont/parametric-curves/blob/main/Images/hermite1_render.PNG)

![hermite values 2](https://github.com/vclimpont/parametric-curves/blob/main/Images/hermite2_values.PNG)
![hermite render 2](https://github.com/vclimpont/parametric-curves/blob/main/Images/hermite2_render.PNG)
 
## Bézier curve

The current implementation uses a Berstein polynomial to plot Bézier curves with 4 control points.
The inputs controller allows to move the control points location at runtime to modify the shape of the curve.

![bézier 1](https://github.com/vclimpont/parametric-curves/blob/main/Images/bezier1.PNG)

![bézier 2](https://github.com/vclimpont/parametric-curves/blob/main/Images/bezier2.PNG)

# Chaikin curve

This algorithm allows to smooth shapes by subdivising and replacing every pairs of points based on a percentage of their location.

In this implementation, 2 new points *P0'* and *P1'* are created for every pairs of points *P0* and *P1* such as :
* *P0' = P0 * 0.75 + P1 * 0.25*
* *P1' = P0 * 0.25 + P1 * 0.75*

![chaikin 1](https://github.com/vclimpont/parametric-curves/blob/main/Images/chaikin1.PNG)

![chaikin 2](https://github.com/vclimpont/parametric-curves/blob/main/Images/chaikin2.PNG)

![chaikin 3](https://github.com/vclimpont/parametric-curves/blob/main/Images/chaikin3.PNG)

# Joint curves

The idea here is to maintain a continuity between multiple Bézier curves.
For this, the algorithm aligns the tangent of the first point of a curve with the tangent of the last point of its neighbour curve.

![Joint curve 1](https://github.com/vclimpont/parametric-curves/blob/main/Images/jointcurve1.PNG)

![Joint curve 2](https://github.com/vclimpont/parametric-curves/blob/main/Images/jointcurve2.PNG)



