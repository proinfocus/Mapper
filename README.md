# Mapper
A C# helper class to map data either object to object or a list of objects to another list of objects.

## Methods
### Map
Maps single object to another object for matching properties.

### MapList
Maps a list of objects to another list of objects for matching properties.

### Examples

The following example maps a Person object to Student object.
<br/><b><code>Mapper.Map(person, student);</code></b>
<br/>or <b><code>person.Map(student);</code></b>

The following example maps a List of People to a List of Students.
<br/><b><code>Mapper.MapList(people, students);</code></b>
<br/>or <b><code>people.MapList(students);</code></b>
