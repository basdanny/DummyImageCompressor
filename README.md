# DummyImageCompressor
The following utility compresses (jpg) image files in order to reduce size. E.g., to send images in the emails.

Drop jpeg files on the "DummyImageCompressor.exe". New compressed files will be placed in the original directory having '_' sign as a prefix.           
Default image dimensions are 1920x1080 . For custom dimensions size, use the following parameters (one or both) when calling the app: `width=_here_goes_the_value_` `height=_here_goes_the_value_`
            

## Build

### .NET Framework
Build the solution (in VS or MSBuild).
Drop jpeg files on the "DummyImageCompressor.exe". New compressed files will be placed in the original directory having '_' sign as a prefix.
##### Prerequisites
.NET 4.6.x



### .NET Core
run from terminal 
`dotnet build`
#### Prerequisites
.NET 5.x