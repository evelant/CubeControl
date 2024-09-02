
## Devices Model

### Problems with existing solutions

Existing home automation systems typically model devices like this:

- A home is a container for everything
- A room/area is a container for devices
- A physical device is directly linked to a room/area
- Physical devices have attributes and capabilities
- Physical devices belong to classes representing general categories of device capabilities
- Automations and dashboards directly reference physical devices
- Optional groups and virtual devices

This model bumps into a few smaller problems in practice

- A device doesn't always make sense as belonging to an area or a single area
- A single device as a unit of control doesn't always make sense, such as a light fixture with multiple smart bulbs. This requires using a separate group concept which doesn't have first class behavior.
- Variants between physical devices don't always line up with device classes making it harder to fully utilize device capabilities

And major problems 

- If you change or replace a physical device it breaks any configuration that has been done in automations and dashboards
- If a physical device malfunctions or loses connection the scope of the breakage isn't immediately obvious

### Proposed model

- A single type of virtual model that can represent an area, concept, group, or device
- The virtual model is nestable and relatable to other models
- Physical devices contribute their capabilities to virtual models
- Each physical device implicitly creates a new virtual model unless it already has one
- Nested virtual models contribute all capabilities to their parents
- Automation and UI is configured against the capabilities of virtual models, not physical devices

This model could potentially solve the problems presented above. 

- Changing a physical device won't require changing automations or UI as long as the capabilities are present
- Makes it easy to present to the user exactly what is impacted by changing a physical device or a physical device being unavailable
- Flexible way to represent whatever the user needs. There are practically infinite ways users might want to combine and relate devices. The model should not restrict that.

### Example

- A home is the top level
- A floor is inside a home
- A living room is inside a floor
- A lamp is inside a room
  - The lamp contains 3 physical smart bulb devices
- A motion sensor is inside the room
  - There are three physical motion sensors in the room
    - one near the entrance
    - one near the closet
    - another near the couch
- A closet is inside the living room
  - A smart bulb is inside the closet

This allows flexibly handling a lot of scenarios

- The rooms implicitly have the capabilities of lights and motion sensors. This makes it easy to "turn on the lights when someone enters the room and turn them off when they leave"
- The individual motion sensors can still be used for automation. For example "turn on the closet lights when the motion sensor near the closet is active, but not the other sensors in the room"
- If you replace any of the physical motion sensors or bulbs in the room the automations and UI are unaffected
- Automations can be constrained to layers of models. For example "turn on all the lights on the floor" could be configured to exclude sub-rooms so all the room lights turn on but the closet lights do not.

### Potential problems and questions

- What do we call such a generalized model that makes intuitive sense to most people?
- Does this make more sense as "tags"? It's arbitrary groupings of capabilities with parent/child/sibling relations.
- How do we guide the user to a default logical setup of home, floors, rooms, groups, devices without constraining them to that?
- What relations other than parent/child/sibling might be useful?
- How do we make best and most intuitive use of relations?
- How best to present groups of capabilities? 
  - For example a color bulb and a non color bulb in the same room. Present it as a color bulb and ignore unsupported changes on the non-color bulb?
- 
