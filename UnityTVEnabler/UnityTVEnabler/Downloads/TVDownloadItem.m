//
//  TVDownloadItem.m
//  UnityTVEnabler
//
//  Created by Mihailo Gazda on 18/11/2016.
//  Copyright © 2016 MihailoGazda. All rights reserved.
//

#import "TVDownloadItem.h"

@implementation TVDownloadItem

@synthesize url;

- (id) initWithURL:(NSURL *)urL
{
    id s = [super init];
    
    self.url = urL;
    
    return s;
}

@end
