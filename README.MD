

<div align="center">
<h1>CubeControl</h1>
  <img src="https://github.com/evelant/CubeControl/blob/main/assets/icon1.jpeg?raw=true" width="256" height="256" alt="description" />
    <h3>
A friendly weighted home automation cube to assimilate all of your devices. Manufacturer specific API resistance is futile.
</h3>
</div>


### Status

At the moment the cake is indeed a lie. There's nothing much here but an empty app scaffold. 
This is a project for myself to learn F# and try .net cross platform tools, Avalonia in this case.

### Stack
* 100% F#
* .net 9 sdk preview
* Fabulous.Avalonia for cross platform UI

### Motivation
I want to learn F# and try new cross platform tools outside of the TS ecosystem.

I'm irritated by the instability and performance of Home Assistant. 
IMO untyped interpreted languages like python are not suitable for such complex systems. 
I think the choice of Python for home assistant makes it fundamentally impossible for it to be performant or reliable in the face of change.

I chose F# for this project because:
* very safe (catch many bugs at compile time and make illegal states unrepresentable)
* runs on all platforms including browsers and mobile
* can be extremely productive
* easy to read and maintain
* has robust tools to manage complexity and is resilient in the face of refactoring
* has an enormous ecosystem of high quality libraries
* it's faster than dynamic languages and has real multithreading support
* amenable to building DSLs for users to automate and extend

I think that a home automation system written in a high performance strongly typed functional language will be able to evolve faster and be much more reliable than those written in untyped languages.

### Design goals

* Runs on any platform, not necessarily needing docker
* Fast, beautiful, UI clients on all platforms. Avalonia can even target embedded devices.
* Automation model that better captures and _reliably_ executes user intentions. The "fire and forget" nature of actions in Home Asssistant cause a lot of problems. Commands should be resilient in the face of failures.
* Experiment with a rules engine for driving automations instead of the usual "if this then that" one-shot event handling systems commonly used.
* Device model designed for resilience
* Device model designed for introspection by AI tools to enable experiences that feel "magical" to users
* Loose coupling of parts with strongly typed communication between them. Assimilations (integrations) should be usable by other projects via well defined and consistent APIs.