# DONT_USE_NOTES

This was a hacky attempt (it did work) to boot Unity inside the tvOS app, before Unity added TVOS platform itself. 
Since original apps had hard file size limitations, this approach would allow you to avoid asset bundles, and just download the whole game as a package, when done boot the Unity Engine. 

Makes little sense to use anymore.

# ORIGINAL NOTES
UnityAppController.mm patch

- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
}


String to search:

	UnityInitApplicationNoGraphics([[[NSBundle mainBundle] bundlePath] UTF8String]);
	
	
	
Replace with:
    NSString* currentDir = [[NSBundle mainBundle] bundlePath];
    NSLog(@"Detected working path: %@", currentDir);
    NSString* newDir = [currentDir stringByAppendingString:@"/Data2/"];

	UnityInitApplicationNoGraphics([newDir UTF8String]);
	
	

- (void)applicationDidBecomeActive:(UIApplication*)application
	return != ready;
	
	
Create window before calling back TVEnableUnity

_window			= [[UIWindow alloc] initWithFrame:[UIScreen mainScreen].bounds];
- (void) TVEnablerInitializeUnity:(NSString *)path


then call applicationDidBecomeActive once more :) 

