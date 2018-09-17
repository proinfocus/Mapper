# Mapper
A C# helper class to map data either object to object or a list of objects to another list of objects.

## Map
Maps single object to another object for matching properties.

## MapList
Maps a list of objects to another list of objects for matching properties.

### Examples

The following example maps a Person object to Student object.
<br/><b><code>Mapper.Map(person, student);</code></b>

The following example maps a List of People to a List of Students.
<br/><b><code>Mapper.MapList(people, students);</code></b>
