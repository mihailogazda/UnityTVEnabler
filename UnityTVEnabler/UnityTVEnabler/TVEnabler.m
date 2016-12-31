//
//  TVEnabler.m
//  UnityTVEnabler
//
//  Created by Mihailo Gazda on 18/11/2016.
//  Copyright © 2016 MihailoGazda. All rights reserved.
//

#import "TVEnabler.h"
#import "TVEnabler+Private.h"
#import "TVLog.h"
#import "TVEnablerViewController.h"

//  We fake here UnityAppViewController as we know how we patched the original class
@interface UnityAppController
- (void) TVEnablerInitializeUnity: (NSString*) path;
@end

@implementation TVEnabler

@synthesize enabledPath;
@synthesize appController;
@synthesize viewController;

static TVEnabler* g_enabler = nil;

+ (id) shared
{
    if (g_enabler == nil)
    {
        [TVLog info:@"TVEnabler instance created."];
        g_enabler = [[TVEnabler alloc] init];
    }
    return g_enabler;
}

- (id) init
{
    id s = [super init];
    
    self.viewController = nil;
    self.enabledPath = nil;
    
    return s;
}

- (void) startWith:(UIWindow *)window andAppControler:(NSObject *)appController
{
    NSBundle* tvKit = [NSBundle bundleForClass:TVEnablerViewController.class];
    UIStoryboard* board = [UIStoryboard storyboardWithName:@"TVEnablerStoryboard" bundle: tvKit];
    [TVLog info:[NSString stringWithFormat:@"Storyboard found: %@", board != nil ? @"YES" : @"NO"]];
    
    //  Store value
    self.appController = (UnityAppController*) appController;
    
    if (board != nil)
    {
        [TVLog info:@"Booting TVEnabler!"];
        
        bool loaded = [tvKit load];
        [TVLog info:[NSString stringWithFormat:@"TVKit Loaded %@", loaded ? @"YES!" : @"NO."]];
        
        self.viewController = [board instantiateInitialViewController];
        [TVLog info:[NSString stringWithFormat:@"Storyboard Loaded %@", self.viewController != nil ? @"YES!" : @"NO."]];
        
        window.rootViewController = self.viewController;
        [window addSubview:self.viewController.view];
        [window makeKeyAndVisible];
    }
}

#pragma mark PRIVATE SECTION

- (void) initializeUnity;
{
    [TVLog info:@"All done! Initalizing Unity!"];
    
    NSString* currentDir = [[NSBundle mainBundle] bundlePath];
    NSLog(@"Detected working path: %@", currentDir);
    NSString* newDir = [currentDir stringByAppendingString:@"/Data2/"];
    
    if (self.appController != nil)
    {
        
    
        //  Fake Unity message send! :)
        [self.appController TVEnablerInitializeUnity: newDir];
    }
}



@end
