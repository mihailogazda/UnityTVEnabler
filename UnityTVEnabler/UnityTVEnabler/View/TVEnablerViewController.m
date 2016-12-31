//
//  TVEnablerViewController.m
//  UnityTVEnabler
//
//  Created by Mihailo Gazda on 18/11/2016.
//  Copyright © 2016 MihailoGazda. All rights reserved.
//

#import "TVEnablerViewController.h"
#import "TVEnabler.h"
#import "TVEnabler+Private.h"

@interface TVEnablerViewController ()



@end

@implementation TVEnablerViewController

@synthesize appName;


- (void)viewDidLoad {
    [super viewDidLoad];
    
    // Do any additional setup after loading the view.
    
    NSString* name = [[[NSBundle mainBundle] infoDictionary]  objectForKey:(id)@"CFBundleDisplayName"];
    [self.appName setText: name];
    
    
    //  Timeout
    [self performSelector:@selector(executeAfter) withObject:nil afterDelay:10];
}

- (void) executeAfter
{
    [[TVEnabler shared] initializeUnity];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
