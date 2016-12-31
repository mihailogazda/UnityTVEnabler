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

