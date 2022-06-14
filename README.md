# Spacecraft Travel

## **Introduction**
```
The Spacecraft Travel Project aims to calculate the route of a travel between planets,
taking into account the maximum travel capacity of the spacecraft, in addition to its
tribulation capacity. The purpose here, is also aims to practice OO language concepts,
using C# and Graphical Framework.
```
------------

#### **Main screen**
The Main Screen presents all the option buttons that the user can use. By default, most buttons are only unlocked after choosing a spaceship or after loading a previously calculated route.

<img src="https://github.com/iagohribeiro/spacecraftTravel/blob/master/isarAssignment/doc/homePage.PNG" width="500">

------------

#### **Capacity**
Each Spacecraft has its own capability. Therefore, the number of passengers dropbox varies according to the chosen Spacecraft.

<img src="https://github.com/iagohribeiro/spacecraftTravel/blob/master/isarAssignment/doc/capacity.PNG" width="500">

------------

#### **Destination**
This dropbox has a number of planets that can be chosen. With each selection of a planet, the Destination List is populated. If you want to exclude a planet from the Destination list, just click on the planet and it will be removed.

<img src="https://github.com/iagohribeiro/spacecraftTravel/blob/master/isarAssignment/doc/destinationList.PNG" width="500">

The list of Destinations shown in the figure below, is populated according to the maximum capacity calculated by Equation 1. This equation takes into account the travel capacity of the spacecraft and the number of crew members. Each passenger decreases linearly the maximum distance a spacecraft can travel, up to a total loss of 30% when the capacity is maximum.

`maxDistanceSupported = MaxTravelDistance * (1 - (0.3 / spacecraftCapacity) * chosenPassengers)` **(Equation 1)**

- **MaxTravelDistance** - Maximum distance supported by the spacecraft, considering 0% degradation (empty spacecraft)

- **0.3 / spacecraftCapacity** - 30% is the maximum degration, divided by spacecraft maximum passenger capacity.

- **chosenPassengers** - Number of passengers chosen by the user

<img src="https://github.com/iagohribeiro/spacecraftTravel/blob/master/isarAssignment/doc/destinationSelect.PNG" width="500">

At each choice of a destination, the capacity of the spacecraft will decrease, considering how much it will spend for that destination previously chosen. So, at each destiny choice, the Destinations list can change and present only the destinations that the spaceship is able to go considering the already chosen destinations.

------------

#### **Create Route**
After selecting all the routes and pressing the `Create Route` button, the route chosen by the user will be shown, considering that the user will ALWAYS leave the Earth and return to it. Besides that, it is also shown the capacity that the spaceship still has.

<img src="https://github.com/iagohribeiro/spacecraftTravel/blob/master/isarAssignment/doc/routeResult.PNG" width="500">

------------

#### **Save**
If the user wants to save a file, when clicking on the `Save Route` button, a screen will appear for him to choose the place where he wants to save the file and, after that, the file will be generated with some necessary data for when he wants to reopen where he left off. 

<img src="https://github.com/iagohribeiro/spacecraftTravel/blob/master/isarAssignment/doc/saveRoute.PNG" width="500">

------------

#### **Open**
To open a file, simply click the `Load File` button and select the desired file. The data in this file, if it follows the pattern defined by the software, will be loaded and added from the UI.
