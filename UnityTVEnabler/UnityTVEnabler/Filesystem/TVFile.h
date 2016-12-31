//
//  TVResource.h
//  UnityTVEnabler
//
//  Created by Mihailo Gazda on 18/11/2016.
//  Copyright © 2016 MihailoGazda. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TVFile : NSObject

@property (nonatomic, copy) NSString* path;

/*
 *  Checks if integrity of resource is intact
 */
- (BOOL) checkForIntegrity;

@end
